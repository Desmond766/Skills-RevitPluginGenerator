---
kind: property
id: P:Autodesk.Revit.DB.ReferenceWithContext.IsValidObject
source: html/19583369-5375-e195-7384-345e59a565ca.htm
---
# Autodesk.Revit.DB.ReferenceWithContext.IsValidObject Property

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

