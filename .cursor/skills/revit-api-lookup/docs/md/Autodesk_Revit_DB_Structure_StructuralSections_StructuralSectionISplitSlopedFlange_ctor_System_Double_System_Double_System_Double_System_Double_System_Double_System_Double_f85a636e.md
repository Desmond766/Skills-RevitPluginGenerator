---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionISplitSlopedFlange.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double)
source: html/8f496c5a-7013-44a4-860a-281b7232485a.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionISplitSlopedFlange.#ctor Method

Creates a new instance of Structural Section I Split Sloped Flange shape with the associated set of parameters,
 used to attach to structural element.

## Syntax (C#)
```csharp
public StructuralSectionISplitSlopedFlange(
	double width,
	double height,
	double flangeThickness,
	double flangeThicknessLocation,
	double webThickness,
	double webFillet,
	double flangeFillet,
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
	double shearAreaWeakAxis,
	double clearWebHeight,
	double webToeOfFillet,
	double boltSpacing,
	double boltDiameter,
	double slopedFlangeAngle
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **flangeThickness** (`System.Double`) - Flange Thickness.
- **flangeThicknessLocation** (`System.Double`) - Flange Thickness Location.
- **webThickness** (`System.Double`) - Web Thickness.
- **webFillet** (`System.Double`) - Web Fillet - fillet radius between web and flange.
- **flangeFillet** (`System.Double`) - Flange Fillet - fillet radius at the flange end.
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
- **clearWebHeight** (`System.Double`) - Detailing depth between the web toes of the fillets, in.(mm)
- **webToeOfFillet** (`System.Double`) - Detailing distance from outer face of flange to web toe of fillet, in. (mm)
- **boltSpacing** (`System.Double`) - Standard bolt spacing, in. (mm)
- **boltDiameter** (`System.Double`) - Maximum bolt hole diameter, in. (mm)
- **slopedFlangeAngle** (`System.Double`) - Sloped flange angle. (rad)

