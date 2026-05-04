---
kind: property
id: P:Autodesk.Revit.UI.IFCExternalServiceUIData.IsValidObject
source: html/6e56583b-9a50-8780-556c-e7e35fab152d.htm
---
# Autodesk.Revit.UI.IFCExternalServiceUIData.IsValidObject Property

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

