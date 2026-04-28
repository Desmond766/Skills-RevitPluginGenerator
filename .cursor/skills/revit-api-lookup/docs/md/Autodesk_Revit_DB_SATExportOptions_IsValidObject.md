---
kind: property
id: P:Autodesk.Revit.DB.SATExportOptions.IsValidObject
source: html/00b47708-0e6b-0bfa-2616-b4ae93c76e53.htm
---
# Autodesk.Revit.DB.SATExportOptions.IsValidObject Property

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

