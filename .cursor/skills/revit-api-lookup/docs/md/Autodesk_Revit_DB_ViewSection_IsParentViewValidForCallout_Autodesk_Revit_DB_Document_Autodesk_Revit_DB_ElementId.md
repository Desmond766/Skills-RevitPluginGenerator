---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.IsParentViewValidForCallout(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 剖面视图、剖面
source: html/75084fdb-bd7e-9dba-dffc-2ed346f1ae5f.htm
---
# Autodesk.Revit.DB.ViewSection.IsParentViewValidForCallout Method

**中文**: 剖面视图、剖面

This validator checks that the parent view is appropriate for callout views.

## Syntax (C#)
```csharp
public static bool IsParentViewValidForCallout(
	Document document,
	ElementId parentViewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document which contains the ViewFamilyType and parent view.
- **parentViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the new callout will appear.
 Callouts can be created in FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation,
 and Detail views.

## Returns
True if the ViewFamilyType can be used for callout views in the parent view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

