---
kind: property
id: P:Autodesk.Revit.DB.Color.Green
zh: 着色、上色、染色、填色
source: html/f44aa41d-1bba-c181-26f8-1af4a5d05e38.htm
---
# Autodesk.Revit.DB.Color.Green Property

**中文**: 着色、上色、染色、填色

Get the green channel of the color. Setting a channel is obsolete in Autodesk Revit 2013. Please create a new color instead.

## Syntax (C#)
```csharp
public byte Green { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When getting the value: the color is invalid or uninitialized.

