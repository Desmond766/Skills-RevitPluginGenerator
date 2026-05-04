---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionRectangleHSS.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double)
source: html/f32bc888-da37-c5a7-71e4-0838f0d46393.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionRectangleHSS.#ctor Method

Creates a new instance of Structural Section Rectangle HSS shape with the associated set of parameters,
 used to attach to structural element.

## Syntax (C#)
```csharp
public StructuralSectionRectangleHSS(
	double width,
	double height,
	double wallNominalThickness,
	double wallDesignThickness,
	double innerFillet,
	double outerFillet,
	double centroidHorizontal,
	double centroidVertical,
	double principalAxesAngle,
	double sectionArea,
	double perimeter,
	double nominalWeight,
	double momentOfInertiaStrongAxis,
	double momentOfInertiaWeakAxis,
	double elasticModulusStrongAxis,
	double elasticModulusWeakAxis,
	double plasticModulusStrongAxis,
	double plasticModulusWeakAxis,
	double torsionalMomentOfInertia,
	double torsionalModulus,
	double warpingConstant,
	double shearAreaStrongAxis,
	double shearAreaWeakAxis
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **wallNominalThickness** (`System.Double`) - Represents wall nominal thickness of rectangle.
- **wallDesignThickness** (`System.Double`) - Represents wall design thickness of rectangle.
- **innerFillet** (`System.Double`) - Inner Fillet - Corner fillet inner radius.
- **outerFillet** (`System.Double`) - Outer Fillet - Corner fillet outer radius.
- **centroidHorizontal** (`System.Double`) - Distance from centroid to the left extremites along horizontal axis.
- **centroidVertical** (`System.Double`) - Distance from centroid to the upper extremites along vertical axis.
- **principalAxesAngle** (`System.Double`) - Rotation angle between the principal axes and cross section reference planes.
- **sectionArea** (`System.Double`) - Cross section area.
- **perimeter** (`System.Double`) - Painting surface of the unit length.
- **nominalWeight** (`System.Double`) - Unit weight (not mass) per unit length, for self-weight calculation or quantity survey.
- **momentOfInertiaStrongAxis** (`System.Double`) - Moment of Inertia about main strong axis (I).
- **momentOfInertiaWeakAxis** (`System.Double`) - Moment of Inertia about main weak axis (I).
- **elasticModulusStrongAxis** (`System.Double`) - Elastic section modulus about main strong axis for calculation of bending stresses.
- **elasticModulusWeakAxis** (`System.Double`) - Elastic section modulus about main weak axis for calculation of bending stresses.
- **plasticModulusStrongAxis** (`System.Double`) - Plastic section modulus in bending about main strong axis (Z, Wpl)
- **plasticModulusWeakAxis** (`System.Double`) - Plastic section modulus in bending about main weak axis.
- **torsionalMomentOfInertia** (`System.Double`) - Torsional Moment of inertia (J, IT, K), for calculation of torsional deformation
- **torsionalModulus** (`System.Double`) - Section modulus for calculations of torsion stresses (Ct)
- **warpingConstant** (`System.Double`) - Warping constant (Cw, Iomega, H)
- **shearAreaStrongAxis** (`System.Double`) - Shear area (reduced extreme shear stress coefficient) in the direction of strong axis (Wq).
- **shearAreaWeakAxis** (`System.Double`) - Shear area (reduced extreme shear stress coefficient) in the direction of weak axis (Wq).

