---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.Behavior
source: html/252cef19-70a6-5efe-986e-9e2c98264306.htm
---
# Autodesk.Revit.DB.StructuralAsset.Behavior Property

Flag indicating whether elements of this material behave isotropically or orthotropically.

## Syntax (C#)
```csharp
public StructuralBehavior Behavior { get; set; }
```

## Remarks
Applies to concrete, Metal, and generic structural assets.
 If the behavior is set to Isotropic, then the y and z components of Young modulus,
 Poisson modulus, shear modulus and thermal expansion coefficient will be changed to
 the value the same as their x components.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

