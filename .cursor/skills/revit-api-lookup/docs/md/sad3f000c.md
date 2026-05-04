---
kind: property
id: P:Autodesk.Revit.DB.FailureHandlingOptions.IsValidObject
source: html/c789080c-31e9-e1b7-236c-23746ed56cd6.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.IsValidObject Property

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

