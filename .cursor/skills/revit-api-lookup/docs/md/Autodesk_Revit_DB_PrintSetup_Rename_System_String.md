---
kind: method
id: M:Autodesk.Revit.DB.PrintSetup.Rename(System.String)
zh: 重命名
source: html/ce2e12e0-8875-7238-26d4-3fd323142899.htm
---
# Autodesk.Revit.DB.PrintSetup.Rename Method

**中文**: 重命名

Rename the current print setting with the specified name.

## Syntax (C#)
```csharp
public bool Rename(
	string newName
)
```

## Parameters
- **newName** (`System.String`) - print setting name to be renamed as.

## Returns
False if Rename operation fails, otherwise true.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input newName already exists in current print setting list.

