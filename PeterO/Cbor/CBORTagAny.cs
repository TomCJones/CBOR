/*
Written by Peter O. in 2014.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.dreamhosters.com/articles/donate-now-2/
 */
using System;

namespace PeterO.Cbor {
  internal class CBORTagAny : ICBORTag
  {
    public CBORTypeFilter GetTypeFilter() {
      return CBORTypeFilter.Any;
    }

    public CBORObject ValidateObject(CBORObject obj) {
      #if DEBUG
      if (obj == null) {
        throw new ArgumentNullException("obj");
      }
      #endif
      return obj;
    }
  }
}
