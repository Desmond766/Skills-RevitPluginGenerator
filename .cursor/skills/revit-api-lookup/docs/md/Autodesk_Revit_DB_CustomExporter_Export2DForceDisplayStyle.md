---
kind: property
id: P:Autodesk.Revit.DB.CustomExporter.Export2DForceDisplayStyle
source: html/47ed429b-289a-207d-0176-707158a46df0.htm
---
# Autodesk.Revit.DB.CustomExporter.Export2DForceDisplayStyle Property

This value tells the exporter of 2D views to force the given display mode for the view.

## Syntax (C#)
```csharp
public DisplayStyle Export2DForceDisplayStyle { get; set; }
```

## Remarks
Only DisplayStyle::Wireframe and DisplayStyle::HLR values are supported.
 Default forced value is DisplayStyle::HLR unless the view has DisplayStyle:Wireframe.
See notes for 2D export for views in non-Wireframe display style in [!:Autodesk::Revit::DB::IExportContextBase] and IExportContext2D .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

