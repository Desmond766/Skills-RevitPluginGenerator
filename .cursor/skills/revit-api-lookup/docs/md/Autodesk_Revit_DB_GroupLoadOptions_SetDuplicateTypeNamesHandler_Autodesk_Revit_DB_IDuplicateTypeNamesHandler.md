---
kind: method
id: M:Autodesk.Revit.DB.GroupLoadOptions.SetDuplicateTypeNamesHandler(Autodesk.Revit.DB.IDuplicateTypeNamesHandler)
source: html/37ce886d-73af-a152-d18e-c088c2b49c77.htm
---
# Autodesk.Revit.DB.GroupLoadOptions.SetDuplicateTypeNamesHandler Method

Sets a custom duplicate type names handler. If this value is not set, the default handler is used.
 By default, Revit displays a modal dialog with options to either copy new types only, or cancel the operation.

## Syntax (C#)
```csharp
public void SetDuplicateTypeNamesHandler(
	IDuplicateTypeNamesHandler handler
)
```

## Parameters
- **handler** (`Autodesk.Revit.DB.IDuplicateTypeNamesHandler`) - The duplicate type names handler.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

