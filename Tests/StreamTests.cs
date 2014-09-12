﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using CoreTechs.Common;
using NUnit.Framework;

namespace Tests
{
    public class StreamTests
    {
        [Test]
        public void CanSeekToBeginningOfByteSequence()
        {
            using (var stream = new Byte[] { 1, 0, 1, 0, 2 }.ToMemoryStream())
            {
                var found = stream.SeekStartOf(new byte[] { 1, 0, 2 });
                Assert.True(found);
                Assert.AreEqual(2, stream.Position);

            }
        }

        [Test]
        public void CanSeekTo_EndOf_ByteSequence()
        {
            using (var stream = new Byte[] { 1, 0, 1, 0, 2 }.ToMemoryStream())
            {
                var found = stream.SeekEndOf(new byte[] { 1, 0, 1 });
                Assert.True(found);
                Assert.AreEqual(3, stream.Position);
            }
        }

        [Test]
        public void CanSeek_ToEndOf_ByteSequence_WhereSequenceIs_AtEndOfStream()
        {
            using (var stream = new Byte[] { 1, 0, 1, 0, 2 }.ToMemoryStream())
            {
                var found = stream.SeekEndOf(new byte[] { 1, 0, 2 });
                Assert.True(found);
                Assert.AreEqual(5, stream.Position);
            }
        }

        [Test]
        public void FalseWhenNotFound()
        {
            using (var stream = new Byte[] { 1, 0, 1, 0, 1 }.ToMemoryStream())
            {
                var found = stream.SeekStartOf(new byte[] { 1, 0, 2 });
                Assert.False(found);
            }
        }

        [Test]
        public void CanSeekToBeginningOfString()
        {                                  //                      1         2         3
            //             012345678901234567890123456789012345678
            using (var stream = Encoding.ASCII.GetBytes("My name is Ronnie Overby. What's yours?").ToMemoryStream())
            {
                var found = stream.SeekStartOf("Ronnie Overby", Encoding.ASCII);
                Assert.True(found);
                Assert.AreEqual(11, stream.Position);
            }
        }

        [Test]
        public void CanSeekToEndOfString()
        {                                  //                      1         2         3
            //             012345678901234567890123456789012345678
            using (var stream = Encoding.ASCII.GetBytes("My name is Ronnie Overby. What's yours?").ToMemoryStream())
            {
                var found = stream.SeekEndOf("Ronnie Overby", Encoding.ASCII);
                Assert.True(found);
                Assert.AreEqual(24, stream.Position);
            }
        }

        [Test]
        public void CanRead_Thru_FindingTarget()
        {
            using (var stream = new byte[] { 1, 0, 1, 0, 2, 0, 3, 0, 2, 0, 1, 0, 1 }.ToMemoryStream())
            {
                var target = new byte[] { 3, 0, 2 };
                var expected = new byte[] { 1, 0, 1, 0, 2, 0 };
                CollectionAssert.AreEqual(stream.EnumerateBytesUntil(target), expected);
            }
        }

        [Test]
        public void CanRead_Thru_FindingTarget_ButItsNotThere()
        {
            using (var stream = new byte[] { 1, 0, 1, 0, 2, 0, 3, 0, 2, 0, 1, 0, 1 }.ToMemoryStream())
            {
                var target = new byte[] { 3, 0, 2, 4 };
                var expected = stream.ToArray();
                var enumerated = stream.EnumerateBytesUntil(target).ToArray();
                CollectionAssert.AreEqual(enumerated, expected);
            }
        }

        [Test]
        public void CanRead_Thru_FindingTargetString()
        {
            const string source = "Ronnie Overby is my name.";
            var stream = Encoding.Default.GetBytes(source).ToMemoryStream();
            var bytes = stream.EnumerateBytesUntil(" is").ToArray();
            var s = Encoding.Default.GetString(bytes);
            Assert.AreEqual("Ronnie Overby", s);
        }

        [Test]
        public void CanFindFirstString()
        {
            const string source = "Ronnie Overby is my name.";
            var stream = Encoding.Default.GetBytes(source).ToMemoryStream();
            var found = stream.SeekEndOfAny(new[] { "Ronnie Overby is my name. AND NOW A WORD", "Ronnie Smith", "Oven", " is" });
            Assert.AreEqual(" is", found);
            Assert.AreEqual(16,stream.Position);
        }

        [Test]
        public void CanFindStringAtCurrentPositon()
        {
            foreach (var item in EnumerateItems())
            {
                
            }
        }

        IEnumerable<object> EnumerateItems()
        {
            const string path = @"C:\Users\roverby\Desktop\USF_COF00001.img";




            using (var stream = File.OpenRead(path))
            {
                const string ItemLoopHeader = "ItemLoopHeader\r\n";
                const string ItemLoopTrailer = "ItemLoopTrailer\r\n";
                const string ItemViewLoopHeader = "ItemViewLoopHeader\r\n";
                const string ItemViewLoopTrailer = "ItemViewLoopTrailer\r\n";
                const string ItemHeader = "Item\r\n";
                const string ItemData = "ItemData\r\n";
                const string View = "View\r\n";
                const string ViewSide = "ViewSide\r\n";
                const string ViewType = "ViewType\r\n";
                const string ViewLength = "ViewLength\r\n";

                var allTokens = new[]
		{ ViewType,
			ItemLoopHeader, ItemLoopTrailer, ItemViewLoopHeader, ItemViewLoopTrailer,
			ItemHeader, View,  ViewSide, ViewLength, ItemData, 
		};

                Item item = null;
                while (true)
                {
                    var found = stream.SeekEndOfAny(allTokens);

                    switch (found)
                    {
                        case ItemHeader:
                            {
                                if (item != null)
                                    yield return item;

                                item = new Item();
                                break;
                            }

                        case ItemData:
                            {
                                var itemData = stream.EnumerateBytesUntil(ItemViewLoopHeader, true).Decode();

                                if (itemData != null)
                                    item.ItemData = itemData.Trim();

                                break;
                            }

                        case View:
                            {
                                var view = new View();
                                item.Views.Add(view);
                                break;
                            }

                        case ViewSide:
                            {
                                var view = item.Views.Last();
                                view.Side = stream.EnumerateBytesUntil(ViewType).Decode().Trim();
                                break;
                            }

                        case ViewType:
                            {
                                var view = item.Views.Last();
                                view.Type = stream.EnumerateBytesUntil(ViewLength).Decode();
                                break;
                            }

                        case ViewLength:
                            {
                                var view = item.Views.Last();
                                view.Length = stream.EnumerateBytesUntil("\r\n").Decode();

                                long end;
                                using (stream.Bookmark())
                                {
                                    stream.SeekStartOfAny(allTokens);
                                    end = stream.Position;
                                }

                                view.Data = stream.EnumerateBytes().Take(end - stream.Position).ToArray();

                                break;
                            }

                        case ItemLoopTrailer:
                        case null:
                            yield break;

                        default: break;
                    }
                }
            }
        }

        class View
        {
            public string Side { get; set; }
            public string Type { get; set; }
            public string Length { get; set; }

            public byte[] Data { get; set; }
        }

        class Item
        {
            public string ItemData { get; set; }
            public List<View> Views { get; set; }

            public Item()
            {
                Views = new List<View>();
            }
        }

    }


}

