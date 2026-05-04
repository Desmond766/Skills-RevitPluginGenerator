---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkOptions.#ctor(System.Boolean,Autodesk.Revit.DB.WorksetConfiguration)
source: html/920a3cc4-f50e-1ef2-b02b-d22a5e87b1e7.htm
---
# Autodesk.Revit.DB.RevitLinkOptions.#ctor Method

Creates a RevitLinkOptions object, specifying relative or absolute path type,
 and the desired workset configuration.

## Syntax (C#)
```csharp
public RevitLinkOptions(
	bool relative,
	WorksetConfiguration config
)
```

## Parameters
- **relative** (`System.Boolean`) - True if the link should use a relative path. False if it should use an
 absolute path.
- **config** (`Autodesk.Revit.DB.WorksetConfiguration`) - A WorksetConfiguration object specifying the worksets to open when creating
 the link.
 Leave as Nothing nullptr a null reference ( Nothing in Visual Basic) if the file is not workshared.
 Optionally, this may also be Nothing nullptr a null reference ( Nothing in Visual Basic) for a workshared
 file, in which case Revit will open all worksets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

