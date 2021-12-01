using Common;
using Common.DataStructures;
using FluentAssertions;
using Xunit;

namespace Tests.DataStructures
{
    public class CircularBufferTests
    {
        [Fact]
        public void Should_Replace0_OnFirstAddition()
        {
            var buffer = new CircularBuffer<int>(1);
            buffer.Add(1, out int replaced);
            replaced.Should().Be(0);
        }

        [Fact]
        public void Should_ReplaceLastValue_OnAdd_WithCapacity1()
        {
            var buffer = new CircularBuffer<int>(1);
            buffer.Capacity.Should().Be(1);
            buffer.Add(1, out int replaced);
            foreach (var value in 2..20)
            {
                buffer.Add(value, out replaced);
                replaced.Should().Be(value - 1);
                buffer[0].Should().Be(value);
                buffer[^0].Should().Be(value);
                buffer.Count.Should().Be(value);
                buffer.Cursor.Should().Be(0);
            }
        }

        [Fact]
        public void Should_NotReplaceValue_OnAdd_WithLargeCapacity()
        {
            var buffer = new CircularBuffer<int>(1000);
            buffer.Capacity.Should().Be(1000);
            buffer.Add(1, out int replaced);
            foreach (var value in 2..20)
            {
                buffer.Add(value, out replaced);
                buffer[0].Should().Be(1);
                buffer[1].Should().Be(2);
                buffer[^0].Should().Be(value);
                buffer[^1].Should().Be(value - 1);
                replaced.Should().Be(0);
                buffer.Count.Should().Be(buffer.Cursor);
            }
        }

        [Fact]
        public void Should_ManageIndex_AsBufferWraps()
        {
            var buffer = new CircularBuffer<int>(3);
            
            buffer.Add(1, out _).Should().Be(false);
            buffer[0].Should().Be(1);
            buffer[^0].Should().Be(1);
            
            buffer.Add(2, out _).Should().Be(false);
            buffer[0].Should().Be(1);
            buffer[1].Should().Be(2);
            buffer[^0].Should().Be(2);
            buffer[^1].Should().Be(1);

            buffer.Add(3, out _).Should().Be(false);
            buffer[0].Should().Be(1);
            buffer[1].Should().Be(2);
            buffer[2].Should().Be(3);
            buffer[^0].Should().Be(3);
            buffer[^1].Should().Be(2);
            buffer[^2].Should().Be(1);

            buffer.Add(4, out int replaced).Should().Be(true); // a value was replaced
            replaced.Should().Be(1);
            buffer[0].Should().Be(2);
            buffer[1].Should().Be(3);
            buffer[2].Should().Be(4);
            buffer[3].Should().Be(2); // wraps, same as buffer[0]
            buffer[^0].Should().Be(4);
            buffer[^1].Should().Be(3);
            buffer[^2].Should().Be(2);
            buffer[^3].Should().Be(4); // wraps, same as buffer[^0]
        }
    }
}
