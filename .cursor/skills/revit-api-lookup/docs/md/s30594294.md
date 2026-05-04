---
kind: property
id: P:Autodesk.Revit.DB.ImportIFCOptions.LinkProcessor
source: html/898d7fa7-94d7-0010-1148-2de2d741fa1c.htm
---
# Autodesk.Revit.DB.ImportIFCOptions.LinkProcessor Property

Specifies the engine to use while doing a Link IFC operation.

## Syntax (C#)
```csharp
public string LinkProcessor { get; set; }
```

## Remarks
This setting allows the user to revert to the legacy Revit link IFC code
 when linking in IFC files, to preserve old behavior. There are three supported
 options:
 Default: let Revit decide the best processor.
 Legacy: use only the legacy Revit Link IFC processor.
 AnyCAD: use AnyCAD to help Link IFC files.
 Any other value (or no entry) will behave as "Default".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

