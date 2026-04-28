---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CreateSimpleCompoundStructure(System.Collections.Generic.IList{Autodesk.Revit.DB.CompoundStructureLayer})
source: html/b4ef2a78-a4c3-8bf6-2709-945f03954ff8.htm
---
# Autodesk.Revit.DB.CompoundStructure.CreateSimpleCompoundStructure Method

Creates a non-vertically compound structure comprised of parallel layers.

## Syntax (C#)
```csharp
public static CompoundStructure CreateSimpleCompoundStructure(
	IList<CompoundStructureLayer> layers
)
```

## Parameters
- **layers** (`System.Collections.Generic.IList < CompoundStructureLayer >`) - An array which describes the parallel layers of this compound structure.

## Returns
A newly created compound structure.

## Remarks
All layers are in the core, i.e. there are no shell layers created.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more layers is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

