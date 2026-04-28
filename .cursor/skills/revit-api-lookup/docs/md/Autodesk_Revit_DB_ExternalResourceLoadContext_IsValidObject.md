---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceLoadContext.IsValidObject
source: html/fe2462b8-491d-16d4-0347-bd1b1b4cd0e6.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContext.IsValidObject Property

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

