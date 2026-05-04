---
kind: method
id: M:Autodesk.Revit.DB.IDuplicateTypeNamesHandler.OnDuplicateTypeNamesFound(Autodesk.Revit.DB.DuplicateTypeNamesHandlerArgs)
source: html/9bdb1ae0-ff1c-5715-6c64-d56db13e706f.htm
---
# Autodesk.Revit.DB.IDuplicateTypeNamesHandler.OnDuplicateTypeNamesFound Method

Called when the destination document contains types with the same names as the types being copied.

## Syntax (C#)
```csharp
DuplicateTypeAction OnDuplicateTypeNamesFound(
	DuplicateTypeNamesHandlerArgs args
)
```

## Parameters
- **args** (`Autodesk.Revit.DB.DuplicateTypeNamesHandlerArgs`) - The information about the types with duplicate names.

## Returns
The action to be taken: copy only types with unique names or cancel the operation.

