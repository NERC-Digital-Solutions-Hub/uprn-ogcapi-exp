using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSH.Hashing.Tests.Models {

  public class ModelA {

    public int Int {
      get; set;
    }

    public long Long {
      get; set;
    }

    public float Float {
      get; set;
    }

    public override int GetHashCode() {
      NdshHashCode hashCode = new();
      hashCode.Add(Int);
      hashCode.Add(Long);
      hashCode.Add(Float);

      return hashCode.ToHashCode();
    }

  }

}
