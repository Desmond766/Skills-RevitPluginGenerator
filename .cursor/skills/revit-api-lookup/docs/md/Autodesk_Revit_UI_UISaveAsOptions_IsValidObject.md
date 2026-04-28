---
kind: property
id: P:Autodesk.Revit.UI.UISaveAsOptions.IsValidObject
source: html/5159b5cb-916b-50d5-0d56-2e886386d5b3.htm
---
# Autodesk.Revit.UI.UISaveAsOptions.IsValidObject Property

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

