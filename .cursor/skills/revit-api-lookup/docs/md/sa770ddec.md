---
kind: method
id: M:Autodesk.Revit.DB.CopyPasteOptions.SetDuplicateTypeNamesHandler(Autodesk.Revit.DB.IDuplicateTypeNamesHandler)
source: html/802f46df-ad49-e580-1147-37e8a2e11783.htm
---
# Autodesk.Revit.DB.CopyPasteOptions.SetDuplicateTypeNamesHandler Method

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

