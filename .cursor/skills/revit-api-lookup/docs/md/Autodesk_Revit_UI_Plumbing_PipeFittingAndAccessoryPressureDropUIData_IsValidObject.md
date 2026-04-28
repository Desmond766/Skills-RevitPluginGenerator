---
kind: property
id: P:Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIData.IsValidObject
source: html/073a2681-a75f-ecae-96b0-f56d8ffa8979.htm
---
# Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIData.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

