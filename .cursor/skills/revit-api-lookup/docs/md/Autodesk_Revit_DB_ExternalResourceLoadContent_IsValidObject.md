---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceLoadContent.IsValidObject
source: html/afe420d6-0130-37aa-d315-8f04523d7467.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContent.IsValidObject Property

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

