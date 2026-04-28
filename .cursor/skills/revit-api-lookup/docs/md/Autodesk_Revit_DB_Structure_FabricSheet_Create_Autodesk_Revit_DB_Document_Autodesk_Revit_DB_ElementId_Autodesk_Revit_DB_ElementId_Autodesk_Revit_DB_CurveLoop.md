---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.CurveLoop)
zh: 创建、新建、生成、建立、新增
source: html/f666c551-91fd-12b8-1a1a-eb91acefb25c.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a single bent Fabric Sheet element within the project.

## Syntax (C#)
```csharp
public static FabricSheet Create(
	Document document,
	ElementId concreteHostElementId,
	ElementId fabricSheetTypeId,
	CurveLoop bendProfile
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the fabric sheet is to be created.
- **concreteHostElementId** (`Autodesk.Revit.DB.ElementId`) - The element that will host the FabricSheet.
 The host can be a Structural Floor, Structural Wall, Structural Slab, Structural Floor Edge, Structural Slab Edge,
 Structural Column, Beam and Brace.
 Also, host can be a [!:Autodesk::Revit::DB::Part] created from a structural layer of Structural Floor, Structural Wall or Structural Slab.
- **fabricSheetTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the FabricSheetType.
- **bendProfile** (`Autodesk.Revit.DB.CurveLoop`) - A profile that defines the bending shape of the fabric sheet.
 The profile can be provided without fillets (eg. for L shape, only two lines not two lines and one arc), if so,
 then fillets (in example one arc) will be automatically generated basing on the Bend Diameter parameter defined in the Fabric Wire system family.
 If the provided profile has no corners (has a tangent defined at each point except the ends), no fillets will be generated.
 The provided profile defines the center-curve of a wire.

## Returns
The instance of the newly created bent fabric sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - concreteHostElementId is not a valid ElementId for the host Fabric Sheet.
 -or-
 fabricSheetTypeId should refer to an FabricSheetType element.
 -or-
 Thrown when the bend profile contains an overlap or intersecting segments.
 -or-
 Thrown when the bend profile is empty.
 -or-
 Thrown when the bend profile contains an empty loop.
 -or-
 Thrown when the bend profile contains multiple loops.
 -or-
 Thrown when the bend profile contains a closed loop.
 -or-
 Thrown when the bend profile contains two or more arcs that are not separated from one another by a straight segment.
 -or-
 Thrown when the bend profile contains too short segments which prevent the fillets from being added. The fillet radius is taken from Bend Diameter parameter defined in the Fabric Wire system family.
 -or-
 Thrown when the provided profile cannot be used as a bending shape for this fabric sheet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

