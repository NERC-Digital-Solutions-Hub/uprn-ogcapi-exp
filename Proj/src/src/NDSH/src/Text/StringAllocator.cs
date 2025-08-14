
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Text {

  //public ref struct StringAllocator {

  //  /// <summary>
  //  /// In this example, we allocate a block of 256 bytes
  //  /// on the stack using stackalloc byte[256]. We then use
  //  /// Encoding.UTF8.GetBytes to convert a string to its UTF-8
  //  /// byte representation and store it in the buffer.
  //  /// Finally, we create a read-only span from the portion
  //  /// of the buffer that contains the UTF-8 bytes and
  //  /// print the string.
  //  /// </summary>
  //  void MyMethod() {
  //    const int bufferSize = 256; // Maximum length of the string in bytes
  //    Span<byte> buffer = stackalloc byte[bufferSize];
  //    var text = "Hello, World!";
  //    var byteCount = Encoding.UTF8.GetBytes(text, buffer);
  //    var utf8String = new ReadOnlySpan<byte>(buffer.Slice(0, byteCount));
  //    Console.WriteLine(Encoding.UTF8.GetString(utf8String));
  //  }

  //  /// <summary>
  //  /// In this example, we allocate a block of 256 characters
  //  /// on the stack using stackalloc char[256]. We then use
  //  /// AsSpan() to get a read-only span of the string,
  //  /// and CopyTo() to copy the characters to the buffer.
  //  /// Finally, we create a read-only span from the portion
  //  /// of the buffer that contains the characters and print
  //  /// the string.
  //  /// </summary>
  //  void MyMethod2() {
  //    const int bufferSize = 256; // Maximum length of the string in characters
  //    Span<char> buffer = stackalloc char[bufferSize];
  //    var text = "Hello, World!";
  //    text.AsSpan().CopyTo(buffer);
  //    var charCount = text.Length;
  //    var charSpan = new ReadOnlySpan<char>(buffer.Slice(0, charCount));
  //    Console.WriteLine(new string(charSpan));
  //  }

    
  //}


  //public ref struct MyRefStruct {

  //  // A property that allocates a UTF-8 encoded string on the stack
  //  public ReadOnlySpan<byte> MyStackAllocatedString {
  //    get {
  //      // Allocate a stack buffer of size 20 bytes
  //      int length = 20;
  //      Span<byte> buffer = stackalloc byte[length];

  //      // Encode the string "Hello, world!" as UTF-8 and store it in the buffer
  //      var bytesWritten = Encoding.UTF8.GetBytes("Hello, world!", buffer);

  //      // Return a ReadOnlySpan that points to the first bytesWritten bytes of the buffer
  //      return buffer.Slice(0, bytesWritten);
  //    }
  //  }

  //  public Span<byte> MyStackAllocatedStringMethod(int length) {

  //    // Allocate a stack buffer of size 'length' bytes
  //    Span<byte> buffer = stackalloc byte[length];

  //    // Encode the string "Hello, world!" as UTF-8 and store it in the buffer
  //    var bytesWritten = Encoding.UTF8.GetBytes("Hello, world!", buffer);

  //    // Return a ReadOnlySpan that points to the first bytesWritten bytes of the buffer
  //    return buffer.Slice(0, bytesWritten);

  //  }

  //}


}
