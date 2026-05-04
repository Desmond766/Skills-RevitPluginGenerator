---
kind: property
id: P:Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.IsValidObject
source: html/4486eb34-a102-5010-903b-0a85b3c8ec56.htm
---
# Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.IsValidObject Property

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

