using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Listify.Models
{
    public class JustInTimeList : IReadOnlyList<int>
        {
            private readonly int _start;
            private readonly int _end;

            public JustInTimeList(int start, int end)
            {
                Count = end - start;
                if (Count < 0)
                    throw new ArgumentOutOfRangeException($"The end parameter({end}) of the range cannot be less that the start parameter({start})!");
                _start = start;
                _end = end;
               
            }
            public IEnumerator<int> GetEnumerator()
            {
                for (var i = _start; i < _end; i++)
                {
                    yield return i;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }


            public int Count { get; }

            public int this[int index]
            {
                get
                {
                    var item = index >= 0 ? _start + index : _end + index + 1;
                    if(!Contains(item))
                        throw new IndexOutOfRangeException($"The supplied index {index} is not within the range");

                    return item;
                }
            }

            public bool Contains(int item)
            {
                return _start <= item && item <= _end;
            }
        }
    }

