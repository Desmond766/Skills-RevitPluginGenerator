---
kind: method
id: M:Autodesk.Revit.DB.ExportDGNSettings.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.DGNExportOptions)
zh: 创建、新建、生成、建立、新增
source: html/c3e93352-1185-5202-9585-ba8e3e760a54.htm
---
# Autodesk.Revit.DB.ExportDGNSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Create DGN export settings with specified values in DGNExportOptions.

## Syntax (C#)
```csharp
public static ExportDGNSettings Create(
	Document document,
	string name,
	DGNExportOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where created settings is saved.
- **name** (`System.String`) - The name specified to this settings.
- **options** (`Autodesk.Revit.DB.DGNExportOptions`) - The options which will be stored in these settings.

## Returns
The new DGN export settings instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ExistOrEmpty
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

