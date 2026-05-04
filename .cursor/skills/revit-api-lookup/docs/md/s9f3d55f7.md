---
kind: property
id: P:Autodesk.Revit.DB.Structure.Rebar.ReadOnlyParameters
zh: 钢筋、配筋
source: html/6e992635-8245-ac60-3514-ca02f6b8e85d.htm
---
# Autodesk.Revit.DB.Structure.Rebar.ReadOnlyParameters Property

**中文**: 钢筋、配筋

When set to true, Rebar will report all its parameters as read only.
 For example, the method Parameter::IsReadOnly() for all Rebar Parameters will return true.
 When set to false, the return value of Parameter::IsReadOnly() will not be affected.

## Syntax (C#)
```csharp
public bool ReadOnlyParameters { get; set; }
```

