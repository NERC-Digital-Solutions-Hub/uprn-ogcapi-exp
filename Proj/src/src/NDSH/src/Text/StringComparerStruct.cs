using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSH.Text {

  //public ref struct StringComparerStruct {
  //  // UTF-8 encoded strings allocated on the stack
  //  private Span<byte> _utf8String1;
  //  private Span<byte> _utf8String2;

  //  // Setter for UTF-8 strings
  //  public void SetUtf8Strings(string utf8String1, string utf8String2) {
  //    // Allocate memory on the stack for the UTF-8 encoded strings
  //    _utf8String1 = stackalloc byte[utf8String1.Length];
  //    _utf8String2 = stackalloc byte[utf8String2.Length];

  //    // Encode the input strings as UTF-8 and copy the bytes to the stack-allocated memory
  //    Encoding.UTF8.GetBytes(utf8String1, _utf8String1);
  //    Encoding.UTF8.GetBytes(utf8String2, _utf8String2);
  //  }

  //  // Getter for UTF-8 strings
  //  public (ReadOnlySpan<byte>, ReadOnlySpan<byte>) GetUtf8Strings() {
  //    return (_utf8String1, _utf8String2);
  //  }

  //  // UTF-16 encoded strings allocated on the stack
  //  private Span<char> _utf16String1;
  //  private Span<char> _utf16String2;

  //  // Setter for UTF-16 strings
  //  public void SetUtf16Strings(string utf16String1, string utf16String2) {
  //    // Allocate memory on the stack for the UTF-16 encoded strings
  //    _utf16String1 = stackalloc char[utf16String1.Length];
  //    _utf16String2 = stackalloc char[utf16String2.Length];

  //    // Copy the input strings to the stack-allocated memory
  //    utf16String1.AsSpan().CopyTo(_utf16String1);
  //    utf16String2.AsSpan().CopyTo(_utf16String2);
  //  }

  //  // Getter for UTF-16 strings
  //  public (ReadOnlySpan<char>, ReadOnlySpan<char>) GetUtf16Strings() {
  //    return (_utf16String1, _utf16String2);
  //  }
  //}

}
