/*
Written by Peter O. in 2013.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://peteroupc.github.io/
 */
using System;
using PeterO.Numbers;
#pragma warning disable CA1036 // This class is obsolete

namespace PeterO {
  /// <include file='../docs.xml'
  /// path='docs/doc[@name="T:PeterO.ExtendedDecimal"]/*'/>
  [Obsolete(
"Use EDecimal from PeterO.Numbers/com.upokecenter.numbers and the output" +
"\u0020of this class's ToString method.")]
  public sealed class ExtendedDecimal : IComparable<ExtendedDecimal>,
IEquatable<ExtendedDecimal> {
    /// <include file='../docs.xml'
    /// path='docs/doc[@name="P:PeterO.ExtendedDecimal.Exponent"]/*'/>
    public BigInteger Exponent {
      get {
        return new BigInteger(this.Ed.Exponent);
      }
    }

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="P:PeterO.ExtendedDecimal.UnsignedMantissa"]/*'/>
    public BigInteger UnsignedMantissa {
      get {
        return new BigInteger(this.Ed.UnsignedMantissa);
      }
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="P:PeterO.ExtendedDecimal.Mantissa"]/*'/>
    public BigInteger Mantissa {
      get {
        return new BigInteger(this.Ed.Mantissa);
      }
    }

    internal static ExtendedDecimal ToLegacy(EDecimal ei) {
      return new ExtendedDecimal(ei);
    }

    internal static EDecimal FromLegacy(ExtendedDecimal bei) {
      return bei.Ed;
    }

    #region Equals and GetHashCode implementation

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="M:PeterO.ExtendedDecimal.Equals(PeterO.ExtendedDecimal)"]/*'/>
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public bool Equals(ExtendedDecimal other) {
      return (other == null) ? false : this.Ed.Equals(other.Ed);
    }

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="M:PeterO.ExtendedDecimal.Equals(System.Object)"]/*'/>
    public override bool Equals(object obj) {
      var bi = obj as ExtendedDecimal;
      return (bi == null) ? false : this.Ed.Equals(bi.Ed);
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.GetHashCode"]/*'/>
    public override int GetHashCode() {
      return this.Ed.GetHashCode();
    }
    #endregion
    private readonly EDecimal ed;

    internal ExtendedDecimal(EDecimal ed) {
      if (ed == null) {
        throw new ArgumentNullException(nameof(ed));
      }
      this.ed = ed;
    }

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="M:PeterO.ExtendedDecimal.Create(PeterO.BigInteger,PeterO.BigInteger)"]/*'/>
    public static ExtendedDecimal Create(
      BigInteger mantissa,
      BigInteger exponent) {
      if (mantissa == null) {
        throw new ArgumentNullException(nameof(mantissa));
      }
      if (exponent == null) {
        throw new ArgumentNullException(nameof(exponent));
      }
      return new ExtendedDecimal(EDecimal.Create(mantissa.Ei, exponent.Ei));
    }

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="M:PeterO.ExtendedDecimal.FromString(System.String)"]/*'/>
    public static ExtendedDecimal FromString(string str) {
      return new ExtendedDecimal(EDecimal.FromString(str));
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.ToSingle"]/*'/>
    public float ToSingle() {
      return this.Ed.ToSingle();
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.ToDouble"]/*'/>
    public double ToDouble() {
      return this.Ed.ToDouble();
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.ToString"]/*'/>
    public override string ToString() {
      return this.Ed.ToString();
    }

    /// <summary>Represents the number 1.</summary>
#if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
                "CA2104", Justification = "ExtendedDecimal is immutable")]
#endif
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public static readonly ExtendedDecimal One =
      ExtendedDecimal.Create(BigInteger.One, BigInteger.Zero);

    /// <summary>Represents the number 0.</summary>
#if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
                "CA2104", Justification = "ExtendedDecimal is immutable")]
#endif
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public static readonly ExtendedDecimal Zero =
      ExtendedDecimal.Create(BigInteger.Zero, BigInteger.Zero);

    /// <summary>Represents the number negative zero.</summary>
#if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
                "CA2104", Justification = "ExtendedDecimal is immutable")]
#endif
    public static readonly ExtendedDecimal NegativeZero =
      new ExtendedDecimal(EDecimal.NegativeZero);

    /// <summary>Represents the number 10.</summary>
#if CODE_ANALYSIS
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
                "CA2104", Justification = "ExtendedDecimal is immutable")]
#endif
    public static readonly ExtendedDecimal Ten =
      new ExtendedDecimal(EDecimal.Ten);

    //----------------------------------------------------------------

    /// <summary>A not-a-number value.</summary>
    public static readonly ExtendedDecimal NaN =
      new ExtendedDecimal(EDecimal.NaN);

    /// <summary>A not-a-number value that signals an invalid operation
    /// flag when it's passed as an argument to any arithmetic operation in
    /// arbitrary-precision decimal.</summary>
    public static readonly ExtendedDecimal SignalingNaN =
      new ExtendedDecimal(EDecimal.SignalingNaN);

    /// <summary>Positive infinity, greater than any other
    /// number.</summary>
    public static readonly ExtendedDecimal PositiveInfinity =
      new ExtendedDecimal(EDecimal.PositiveInfinity);

    /// <summary>Negative infinity, less than any other number.</summary>
    public static readonly ExtendedDecimal NegativeInfinity =
      new ExtendedDecimal(EDecimal.NegativeInfinity);

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.IsNaN"]/*'/>
    public bool IsNaN() {
      return this.Ed.IsNaN();
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.IsInfinity"]/*'/>
    public bool IsInfinity() {
      return this.Ed.IsInfinity();
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="P:PeterO.ExtendedDecimal.IsNegative"]/*'/>
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public bool IsNegative {
      get {
        return this.Ed.IsNegative;
      }
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="M:PeterO.ExtendedDecimal.IsQuietNaN"]/*'/>
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public bool IsQuietNaN() {
      return this.Ed.IsQuietNaN();
    }

    /// <include file='../docs.xml'
    ///   path='docs/doc[@name="M:PeterO.ExtendedDecimal.CompareTo(PeterO.ExtendedDecimal)"]/*'/>
    public int CompareTo(ExtendedDecimal other) {
      return this.Ed.CompareTo(other == null ? null : other.Ed);
    }

    /// <include file='../docs.xml'
    /// path='docs/doc[@name="P:PeterO.ExtendedDecimal.Sign"]/*'/>
    [Obsolete("Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.")]
    public int Sign {
      get {
        return this.Ed.Sign;
      }
    }

    internal EDecimal Ed {
      get {
        return this.ed;
      }
    }
  }
}
