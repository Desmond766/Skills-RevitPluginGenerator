---
kind: property
id: P:Autodesk.Revit.DB.Document.ParameterBindings
zh: 文档、文件
source: html/ce28ad7d-30b7-29d9-8f81-c75aebc03581.htm
---
# Autodesk.Revit.DB.Document.ParameterBindings Property

**中文**: 文档、文件

Retrieves an object from which mappings between parameter definitions and categories can
be found.

## Syntax (C#)
```csharp
public BindingMap ParameterBindings { get; }
```

## Remarks
Returns a mapping between parameter definitions and parameter bindings. New bindings can
be added to the Revit Document by using this object.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When the document is a family document.

