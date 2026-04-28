---
kind: method
id: M:Autodesk.Revit.DB.INavisworksExporter.Export(Autodesk.Revit.DB.Document,System.String,System.String,Autodesk.Revit.DB.NavisworksExportOptions)
zh: 导出、输出
source: html/810c64df-3310-df37-53d5-18db9eb94c53.htm
---
# Autodesk.Revit.DB.INavisworksExporter.Export Method

**中文**: 导出、输出

The method that Revit will invoke to perform an export to Navisworks.

## Syntax (C#)
```csharp
void Export(
	Document document,
	string folder,
	string name,
	NavisworksExportOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to export.
- **folder** (`System.String`) - The folder path.
- **name** (`System.String`) - The file name.
- **options** (`Autodesk.Revit.DB.NavisworksExportOptions`) - The export options.

