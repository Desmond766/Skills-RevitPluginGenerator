---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetWindowOrSkylightConstructionType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.ConceptualConstructionWindowSkylightType)
source: html/5ff744e9-1b68-ac93-4731-68b304548ce8.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualConstructionType.GetWindowOrSkylightConstructionType Method

Get a Window or Skylight ConceptualConstructionType by its ConceptualConstructionWindowSkylightType.

## Syntax (C#)
```csharp
public static ElementId GetWindowOrSkylightConstructionType(
	Document ccda,
	ConceptualConstructionWindowSkylightType typeEnum
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The Document.
- **typeEnum** (`Autodesk.Revit.DB.Analysis.ConceptualConstructionWindowSkylightType`) - The ConceptualConstructionWindowSkylightType to get the ConceptualConstructionType for.

## Returns
Returns ElementId of a ConceptualConstructionType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The enum is invalid for ConceptualConstructionWindowSkylightType.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

