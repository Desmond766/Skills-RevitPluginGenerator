---
kind: property
id: P:Autodesk.Revit.DB.ConnectionValidationInfo.IsValidObject
source: html/4efecb0d-8322-21ae-72e0-9e23a04c117f.htm
---
# Autodesk.Revit.DB.ConnectionValidationInfo.IsValidObject Property

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

