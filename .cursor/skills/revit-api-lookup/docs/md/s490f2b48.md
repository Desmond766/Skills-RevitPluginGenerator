---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarConstraint
source: html/748823c8-f059-68c1-d7b5-7cfaba93a445.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint

A class representing a constraint on a handle of a rebar element.

## Syntax (C#)
```csharp
public class RebarConstraint : IDisposable
```

## Remarks
For Shape Driven Rebar Constraints: Each handle on a rebar is defined by a plane, and can be constrained along the
 direction perpendicular to the plane. Rebar constraints work by locking the
 handle planes to planar references, or 'targets.' These targets can be:
 planar surfaces of host elements, or the handle planes of stirrup bars (only applies to standard style bars). For planar host element surfaces, a rebar handle can either be locked at a constant
 distance, or, if the host surface has a specified cover, then the handle can be
 joined directly to the cover of the surface. Standard style bars can be locked to the handle planes of stirrup style rebar.
 In the special case of a straight, standard style bar, running perpendicular
 to the plane of the stirrup bar, the bar can constrain itself to distinct locations
 along bends in stirrup bars - points located at 0 degrees, 45 degrees, 90 degrees,
 etc. around each bend. This is done by simultaneously locking both the straight
 bar's edge handle and its planar position handle to one or both of the stirrup edges
 adjacent to the bend in the stirrup. Usually, to form a constraint, the handle plane and the reference plane must be parallel.
 However, bar end handles can be constrained to planes at angles up to 60 degrees.
 Arc-shaped rebar is a special case, and can form constraints to concentric host surfaces. RebarConstraints can only be constructed internally by Revit. They are
 available to the API by querying a rebar element's RebarConstraintsManager. For Free Form Rebar Constraints: Each handle of the Rebar can be constrained to multiple host faces or to the face cover. In order to create a Free Form Rebar Constraint you will need:
 RebarConstraintsManager which will manage the constraint. The rebar handle you want to constraint. A list of target references which must be element faces to which this handle is constrained. A Boolean value specifying that the constraint is to cover or directly to face. It will be the same value for all target references A double value that represent the offset distance from the rebar handle to target references. RebarConstraints for Free Form Rebar should be created using the Create method and then added to
 the RebarConstraintsManager using the method SetPreferredConstraintForHandle.

