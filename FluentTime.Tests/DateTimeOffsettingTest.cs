// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;
using NUnit.Framework;

namespace FluentTime.Tests
{
	[TestFixture]
	public class DateTimeOffsettingTest
	{
		private DateTime dt = 1.May(2011).At(4, 23).PM();

		[Test]
		public void DateTime_can_be_offset_by_specified_hours ()
		{
			Assert.That(dt.Offset(-5), Is.EqualTo(new DateTimeOffset(dt, -5.Hours())));
		}

		[Test]
		public void DateTime_can_be_offset_by_specified_TimeSpan ()
		{
			Assert.That(dt.Offset(2.Hours()), Is.EqualTo(new DateTimeOffset(dt, 2.Hours())));
		}
		
		[Test]
		public void DateTime_can_be_offset_for_a_given_system_time_zone_identifier ()
		{
			Assert.That(dt.OffsetFor("Eastern Standard Time"),
			            Is.EqualTo(new DateTimeOffset(dt, -4.Hours())));
		}
		
		[Test]
		public void DateTime_can_be_offset_for_a_given_TimeZoneInfo ()
		{
			var easternTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
			Assert.That(dt.OffsetFor(easternTime),
			            Is.EqualTo(new DateTimeOffset(dt, -4.Hours())));
		}
		
		[Test]
		public void DateTime_can_be_offset_for_local_time_zone ()
		{
			Assert.That(dt.OffsetForLocal(),
			            Is.EqualTo(new DateTimeOffset(dt, TimeZoneInfo.Local.GetUtcOffset(dt))));
		}
	}
}

