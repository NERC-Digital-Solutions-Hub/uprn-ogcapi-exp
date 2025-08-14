using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSH.Hashing.Tests.Models {

  public class ModelC {

    public ModelA ModelA {
      get; set;
    }

    public ModelB ModelB {
      get; set;
    }

    public override int GetHashCode() {
      NdshHashCode hashCode = new();
      hashCode.Add(ModelA);
      hashCode.Add(ModelB);

      return hashCode.ToHashCode();
    }

  }

}
