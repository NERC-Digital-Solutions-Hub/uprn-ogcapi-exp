using NDSH.Hashing.Tests.Models;
using Xunit;

namespace NDSH.Hashing.Tests {

  /// <summary>
  /// Tests for the <see cref="NdshHashCode"/> class.
  /// </summary>
  public class NdshHashCodeTests {

    /// <summary>
    /// Tests if two models have the same hash code when their values are the same.
    /// </summary>
    [Fact]
    public void ModelsHaveSameHashCode_WhenValuesAreTheSame_IsEqual() {
      ModelA model1 = new ModelA { Int = 1, Long = 10, Float = 0.1f };
      ModelA model2 = new ModelA { Int = 1, Long = 10, Float = 0.1f };

      int hash1 = model1.GetHashCode();
      int hash2 = model2.GetHashCode();

      Assert.Equal(hash1, hash2);
    }

    /// <summary>
    /// Tests if two models have different hash code when their values are different.
    /// </summary>
    [Fact]
    public void ModelsHaveDifferentHashCode_WhenValuesDifferent_IsNotEqual() {
      ModelA model1 = new ModelA { Int = 10, Long = 1, Float = 0.2f };
      ModelA model2 = new ModelA { Int = 1, Long = 10, Float = 0.1f };

      int hash1 = model1.GetHashCode();
      int hash2 = model2.GetHashCode();

      Assert.NotEqual(hash1, hash2);
    }

    /// <summary>
    /// Tests if two models have the same hash code when their values are the same but in different order.
    /// While model a and model b have the same values, they are not equal because the order of the values is different.
    /// </summary>
    [Fact]
    public void ModelsHaveDifferentHashCode_WhenValuesAreSameButOrderIsDifferent_IsNotEqual() {
      ModelA model1 = new ModelA { Int = 1, Long = 10, Float = 0.1f };
      ModelB model2 = new ModelB { Int = 1, Float = 0.1f, Long = 10 };

      int hash1 = model1.GetHashCode();
      int hash2 = model2.GetHashCode();

      Assert.NotEqual(hash1, hash2);
    }

    /// <summary>
    /// Tests if two models have the same hash code when their values are reference types with the same values.
    /// </summary>
    [Fact]
    public void ModelsHaveSameHashCode_WhenValuesAreReferenceTypesWithSameValues_IsEqual() {
      ModelC model1 = new ModelC {
        ModelA = new ModelA { Int = 1, Long = 10, Float = 0.1f },
        ModelB = new ModelB { Int = 1, Float = 0.1f, Long = 10 }
      };

      ModelC model2 = new ModelC {
        ModelA = new ModelA { Int = 1, Long = 10, Float = 0.1f },
        ModelB = new ModelB { Int = 1, Float = 0.1f, Long = 10 }
      };

      int hash1 = model1.GetHashCode();
      int hash2 = model2.GetHashCode();

      Assert.Equal(hash1, hash2);
    }

    /// <summary>
    /// Tests if two models have different hash code when their values are reference types with different values.
    /// </summary>
    [Fact]
    public void ModelsHaveDifferentHashCode_WhenValuesAreReferenceTypesWithDifferentValues_IsNotEqual() {
      ModelC model1 = new ModelC {
        ModelA = new ModelA { Int = 10, Long = 1, Float = 0.2f },
        ModelB = new ModelB { Int = 1, Float = 0.1f, Long = 10 }
      };

      ModelC model2 = new ModelC {
        ModelA = new ModelA { Int = 1, Long = 10, Float = 0.1f },
        ModelB = new ModelB { Int = 1, Float = 0.1f, Long = 10 }
      };

      int hash1 = model1.GetHashCode();
      int hash2 = model2.GetHashCode();

      Assert.NotEqual(hash1, hash2);
    }

  }

}
