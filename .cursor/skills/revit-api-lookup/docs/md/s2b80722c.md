---
kind: property
id: P:Autodesk.Revit.UI.UIDocument.IsValidObject
source: html/2163a816-a155-c469-28ba-e40bd8a4d84d.htm
---
# Autodesk.Revit.UI.UIDocument.IsValidObject Property

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

