---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionStructuralTees.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double)
source: html/8f434b05-1718-897f-3ef0-69155969ce25.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionStructuralTees.#ctor Method

Creates a new instance of Structural Section Tees shape with the associated set of parameters,
 used to attach to structural element.

## Syntax (C#)
```csharp
public StructuralSectionStructuralTees(
	double width,
	double height,
	double flangeThickness,
	double flangeThicknessLocation,
	double webThickness,
	double webThicknessLocation,
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
	double boltSpacing,
	double boltSpacingWeb,
	double boltDiameter,
	double slopedFlangeAngle,
	double slopedWebAngle,
	double topWebFillet
)
```

## Parameters
- **width** (`System.Double`) - Section width.
- **height** (`System.Double`) - Section height, depth.
- **flangeThickness** (`System.Double`) - Flange Thickness.
- **flangeThicknessLocation** (`System.Double`) - Flange Thickness Location.
- **webThickness** (`System.Double`) - Web Thickness.
- **webThicknessLocation** (`System.Double`) - Web Thickness Location.
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
- **boltSpacing** (`System.Double`) - Standard bolt spacing in the flange, in. (mm)
- **boltSpacingWeb** (`System.Double`) - Standard bolt spacing in the web, in. (mm)
- **boltDiameter** (`System.Double`) - Maximum bolt hole diameter, in. (mm)
- **slopedFlangeAngle** (`System.Double`) - Sloped flange angle. (rad)
- **slopedWebAngle** (`System.Double`) - Sloped web angle. (rad)
- **topWebFillet** (`System.Double`) - Top Web Fillet - fillet radius at the top of web.

