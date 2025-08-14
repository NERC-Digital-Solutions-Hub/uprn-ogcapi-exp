
namespace NDSH.Math.Distances {

  #region Imported Namespaces

  // Add using statements inside the namespace because Math (System.Math) is used and it conflicts with NDSH.Math
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Numerics;
  using System.Text;
  using System.Threading.Tasks;

  #endregion

  /// <summary>
  /// 
  /// </summary>
  public struct LevenshteinNdsh {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int DistanceUtf8(byte[] s, byte[] t) {

      ArgumentNullException.ThrowIfNull(s, nameof(s));
      ArgumentNullException.ThrowIfNull(t, nameof(t));

      int n = s.Length;
      int m = t.Length;

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        (t, s) = (s, t);

        n = m;
        m = t.Length;
      }

      int[] distance = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int DistanceUtf8(ReadOnlySpan<byte> s, ReadOnlySpan<byte> t) {

      int n = s.Length;
      int m = t.Length;

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        ReadOnlySpan<byte> temp = s;
        s = t;
        t = temp;

        n = m;
        m = t.Length;
      }

      int[]? distance = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int DistanceUtf8(Span<byte> s, Span<byte> t) {

      int n = s.Length;
      int m = t.Length;

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        Span<byte> temp = s;
        s = t;
        t = temp;

        n = m;
        m = t.Length;
      }

      int[]? distance = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static int DistanceUtf16(byte[] s, byte[] t) {

      ArgumentNullException.ThrowIfNull(s, nameof(s));
      ArgumentNullException.ThrowIfNull(t, nameof(t));

      if (s.Length % 2 != 0 || t.Length % 2 != 0) {
        throw new ArgumentException("s or t is not a valid UTF-16 byte array");
      }

      int n = s.Length / 2;
      int m = t.Length / 2;

      char[] sChars = new char[n];
      char[] tChars = new char[m];

      for (int i = 0; i < n; i++) {
        sChars[i] = (char)(s[2 * i] + (s[2 * i + 1] << 8));
      }

      for (int i = 0; i < m; i++) {
        tChars[i] = (char)(t[2 * i] + (t[2 * i + 1] << 8));
      }

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        char[] temp = sChars;
        sChars = tChars;
        tChars = temp;

        n = m;
        m = tChars.Length;
      }

      int[] distance = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = sChars[i - 1] == tChars[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int DistanceUtf16(ReadOnlySpan<byte> s, ReadOnlySpan<byte> t) {

      if (s.Length % 2 != 0 || t.Length % 2 != 0) {
        throw new ArgumentException("s or t is not a valid UTF-16 byte array");
      }

      int n = s.Length / 2;
      int m = t.Length / 2;

      Span<char> sChars = stackalloc char[n];
      Span<char> tChars = stackalloc char[m];

      for (int i = 0; i < n; i++) {
        sChars[i] = (char)(s[2 * i] + (s[2 * i + 1] << 8));
      }

      for (int i = 0; i < m; i++) {
        tChars[i] = (char)(t[2 * i] + (t[2 * i + 1] << 8));
      }

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        Span<char> temp = sChars;
        sChars = tChars;
        tChars = temp;

        n = m;
        m = tChars.Length;
      }

      Span<int> distance = stackalloc int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = sChars[i - 1] == tChars[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int DistanceUtf16(Span<byte> s, Span<byte> t) {
      if (s.Length % 2 != 0 || t.Length % 2 != 0) {
        throw new ArgumentException("s or t is not a valid UTF-16 byte array");
      }

      int n = s.Length / 2;
      int m = t.Length / 2;

      Span<char> sChars = stackalloc char[n];
      Span<char> tChars = stackalloc char[m];

      for (int i = 0; i < n; i++) {
        sChars[i] = (char)(s[2 * i] + (s[2 * i + 1] << 8));
      }

      for (int i = 0; i < m; i++) {
        tChars[i] = (char)(t[2 * i] + (t[2 * i + 1] << 8));
      }

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        Span<char> temp = sChars;
        sChars = tChars;
        tChars = temp;

        n = m;
        m = tChars.Length;
      }

      Span<int> distance = stackalloc int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = sChars[i - 1] == tChars[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int DistanceUtf16(char[] s, char[] t) {

      if (s == null || t == null) {
        throw new ArgumentNullException("s or t");
      }

      int n = s.Length;
      int m = t.Length;

      if (n == 0) {
        return m;
      }
      if (m == 0) {
        return n;
      }

      if (n > m) {
        (t, s) = (s, t);

        n = m;
        m = t.Length;
      }

      int[] distance = new int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf16(ReadOnlySpan<char> s, ReadOnlySpan<char> t) {

      if (s.Length == 0) {
        return t.Length;
      }
      if (t.Length == 0) {
        return s.Length;
      }

      if (s.Length > t.Length) {
        ReadOnlySpan<char> temp = s;
        s = t;
        t = temp;
      }

      int n = s.Length;
      int m = t.Length;

      Span<int> distance = stackalloc int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf16(Span<char> s, Span<char> t) {

      if (s.Length == 0) {
        return t.Length;
      }
      if (t.Length == 0) {
        return s.Length;
      }

      if (s.Length > t.Length) {
        Span<char> temp = s;
        s = t;
        t = temp;
      }

      int n = s.Length;
      int m = t.Length;

      Span<int> distance = stackalloc int[n + 1];

      for (int i = 0; i <= n; i++) {
        distance[i] = i;
      }

      for (int j = 1; j <= m; j++) {
        int diagonal = distance[0];
        distance[0] = j;

        for (int i = 1; i <= n; i++) {
          int previousDiagonal = diagonal;
          diagonal = distance[i];

          int cost = s[i - 1] == t[j - 1] ? 0 : 1;

          int insertion = distance[i - 1] + 1;
          int deletion = diagonal + 1;
          int substitution = previousDiagonal + cost;

          distance[i] = Math.Min(Math.Min(insertion, deletion), substitution);
        }
      }

      return distance[n];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf16BitShift(string s, string t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        for (int i = 1; i <= n; i++) {
          cost = s[i - 1] == t[j - 1] ? 0 : 1;

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          d[i, j] = (del < ins ? del : ins) < sub ? del < ins ? del : ins : sub;
        }
      }

      return d[n, m];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf16BitShift(ReadOnlySpan<char> s, ReadOnlySpan<char> t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        for (int i = 1; i <= n; i++) {
          cost = s[i - 1] == t[j - 1] ? 0 : 1;

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          d[i, j] = (del < ins ? del : ins) < sub ? del < ins ? del : ins : sub;
        }
      }

      return d[n, m];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf16BitShift(Span<char> s, Span<char> t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        for (int i = 1; i <= n; i++) {
          cost = s[i - 1] == t[j - 1] ? 0 : 1;

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          d[i, j] = (del < ins ? del : ins) < sub ? del < ins ? del : ins : sub;
        }
      }

      return d[n, m];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf8BitShift(byte[] s, byte[] t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub, min;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        int tj = t[j - 1];
        for (int i = 1; i <= n; i++) {
          int si = s[i - 1];
          if (si == tj) {
            cost = 0;
          }
          else {
            // Determine the number of leading zeros in the XOR of the two characters.
            int xor = si ^ tj;
            int leadingZeros = BitOperations.LeadingZeroCount((uint)xor);
            // If the leading zeros are less than 7, then the characters have different bit patterns.
            cost = leadingZeros < 7 ? 1 : 2;
          }

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          // Determine the minimum of the three values using bit-shift operators.
          int delOrIns = del < ins ? del : ins;
          min = (delOrIns | sub) & -(delOrIns < sub ? 1 : 0);

          d[i, j] = min;
        }
      }

      return d[n, m];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf8BitShift(ReadOnlySpan<byte> s, ReadOnlySpan<byte> t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub, min;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        byte tj = t[j - 1];
        for (int i = 1; i <= n; i++) {
          byte si = s[i - 1];
          if (si == tj) {
            cost = 0;
          }
          else {
            // Determine the number of leading zeros in the XOR of the two characters.
            int xor = si ^ tj;
            int leadingZeros = BitOperations.LeadingZeroCount((uint)xor);
            // If the leading zeros are less than 7, then the characters have different bit patterns.
            cost = leadingZeros < 7 ? 1 : 2;
          }

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          // Determine the minimum of the three values using bit-shift operators.
          int delOrIns = del < ins ? del : ins;
          min = (delOrIns | sub) & -(delOrIns < sub ? 1 : 0);

          d[i, j] = min;
        }
      }

      return d[n, m];

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static int DistanceUtf8BitShift(Span<byte> s, Span<byte> t) {

      int n = s.Length;
      int m = t.Length;
      int[,] d = new int[n + 1, m + 1];
      int cost, del, ins, sub, min;

      for (int i = 0; i <= n; i++) {
        d[i, 0] = i;
      }

      for (int j = 0; j <= m; j++) {
        d[0, j] = j;
      }

      for (int j = 1; j <= m; j++) {
        byte tj = t[j - 1];
        for (int i = 1; i <= n; i++) {
          byte si = s[i - 1];
          if (si == tj) {
            cost = 0;
          }
          else {
            // Determine the number of leading zeros in the XOR of the two characters.
            int xor = si ^ tj;
            int leadingZeros = BitOperations.LeadingZeroCount((uint)xor);
            // If the leading zeros are less than 7, then the characters have different bit patterns.
            cost = leadingZeros < 7 ? 1 : 2;
          }

          del = d[i - 1, j] + 1;
          ins = d[i, j - 1] + 1;
          sub = d[i - 1, j - 1] + cost;

          // Determine the minimum of the three values using bit-shift operators.
          int delOrIns = del < ins ? del : ins;
          min = (delOrIns | sub) & -(delOrIns < sub ? 1 : 0);

          d[i, j] = min;
        }
      }

      return d[n, m];

    }

  }

}
