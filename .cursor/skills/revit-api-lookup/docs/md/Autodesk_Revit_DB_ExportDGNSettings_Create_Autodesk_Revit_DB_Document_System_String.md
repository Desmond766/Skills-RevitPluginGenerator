---
kind: method
id: M:Autodesk.Revit.DB.ExportDGNSettings.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/4694dfb7-7978-2597-dcdf-6bd87aee1397.htm
---
# Autodesk.Revit.DB.ExportDGNSettings.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a DGN export settings with default values.

## Syntax (C#)
```csharp
public static ExportDGNSettings Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document where created settings is saved.
- **name** (`System.String`) - The name specified to this settings.

## Returns
The new DGN export settings instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ExistOrEmpty
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

