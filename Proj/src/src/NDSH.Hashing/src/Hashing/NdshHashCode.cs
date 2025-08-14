
#region Imported Namespaces

using System.IO.Hashing;
using System.Runtime.CompilerServices;
using System.Text;

#endregion

namespace NDSH.Hashing {

  // WARNING: Move this class in project NDSH (Create namespace NDSH.Hashing)

  /// <summary>
  /// Generates a hash code for a value or a sequence of values.
  /// This implementation is based on the xxHash32 algorithm,
  /// and aims to provide a consistent hash code across different run-times and platforms.
  /// </summary>
  public struct NdshHashCode {

    private const int Seed = 8534857;
    private readonly XxHash32 _hash;

    /// <summary>
    /// Initializes a new instance of the <see cref="NdshHashCode"/> struct.
    /// </summary>
    public NdshHashCode() {
      _hash = new(Seed);
    }

    /// <summary>
    /// Adds the specified value to the <see cref="NdshHashCode"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the object used to add to the hash.</typeparam>
    /// <param name="value">The <paramref name="value"/> to add to the hash.</param>
    public readonly void Add<T>(T value) {
      byte[] bytes = ConvertToBytes(value);
      _hash.Append(bytes);
    }

    /// <summary>
    /// Gets the <see cref="int"/> hash code value of the <see cref="NdshHashCode"/>.
    /// </summary>
    /// <returns>The hash code.</returns>
    public readonly int ToHashCode() {
      byte[] hash = _hash.GetCurrentHash();

      return BitConverter.ToInt32(NormalizeBytes(hash));
    }

    /// <summary>
    /// Converts the specified value to a <see cref="byte"/> <see cref="Array"/>.
    /// </summary>
    /// <remarks>
    /// This will use <see cref="BitConverter"/> to convert primitive types
    /// to <see cref="byte"/> <see cref="Array"/>. If the value is a reference type,
    /// it will use the <see cref="object.GetHashCode"/> method to get the hash code.
    /// <br></br>
    /// Therefore, it is important to override the <see cref="object.GetHashCode"/>
    /// method for reference types to ensure consistent hash codes.
    /// </remarks>
    /// <typeparam name="T">The <see cref="Type"/> of the object used in the conversion.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>
    /// The <paramref name="value"/> converted to <see cref="byte"/> <see cref="Array"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte[] ConvertToBytes<T>(T value) {
      return value switch {
        byte @byte => [@byte],
        sbyte @sbyte => [unchecked((byte)@sbyte)],
        bool @bool => NormalizeBytes(BitConverter.GetBytes(@bool)),
        char @char => NormalizeBytes(BitConverter.GetBytes(@char)),
        short @short => NormalizeBytes(BitConverter.GetBytes(@short)),
        ushort @ushort => NormalizeBytes(BitConverter.GetBytes(@ushort)),
        int @int => NormalizeBytes(BitConverter.GetBytes(@int)),
        uint @uint => NormalizeBytes(BitConverter.GetBytes(@uint)),
        long @long => NormalizeBytes(BitConverter.GetBytes(@long)),
        ulong @ulong => NormalizeBytes(BitConverter.GetBytes(@ulong)),
        float @float => NormalizeBytes(BitConverter.GetBytes(@float)),
        double @double => NormalizeBytes(BitConverter.GetBytes(@double)),
        decimal @decimal => NormalizeBytes(GetDecimalBytes(@decimal)),
        string @string => NormalizeBytes(Encoding.UTF8.GetBytes(@string)),
        _ => NormalizeBytes(BitConverter.GetBytes(value?.GetHashCode() ?? 0)),
      };
    }

    /// <summary>
    /// Gets the <see cref="byte"/> <see cref="Array"/> of a <see cref="decimal"/>.
    /// </summary>
    /// <param name="decimal">The <see cref="decimal"/> value.</param>
    /// <returns>The <see cref="byte"/> <see cref="Array"/> of a <see cref="decimal"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte[] GetDecimalBytes(decimal @decimal) {
      int[] bits = decimal.GetBits(@decimal);
      byte[] bytes = new byte[bits.Length * sizeof(int)];
      Buffer.BlockCopy(bits, 0, bytes, 0, bytes.Length);

      return bytes;
    }

    /// <summary>
    /// Normalizes the specified <see cref="byte"/> <see cref="Array"/> by reversing it if the system does not use
    /// little-endian. This ensures that the <see cref="BitConverter"/> produces the same <see cref="byte"/> 
    /// <see cref="Array"/> on both little-endian and big-endian systems.
    /// </summary>
    /// <param name="bytes">The <see cref="byte"/> <see cref="Array"/> to normalize.</param>
    /// <returns>The normalized <see cref="byte"/> <see cref="Array"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte[] NormalizeBytes(byte[] bytes) {
      if (!BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }

      return bytes;
    }

  }

}
