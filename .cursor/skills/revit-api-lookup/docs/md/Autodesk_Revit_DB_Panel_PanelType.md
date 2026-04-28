---
kind: property
id: P:Autodesk.Revit.DB.Panel.PanelType
zh: 面板
source: html/b2a37660-4c7f-2229-04e9-c85c8dddd9cc.htm
---
# Autodesk.Revit.DB.Panel.PanelType Property

**中文**: 面板

The Panel style of this Panel.

## Syntax (C#)
```csharp
public PanelType PanelType { get; set; }
```

## Remarks
The Symbol property can be used to retrieve the kind of the panel. 
This property can also be used to change the type of a panel by setting it to a different type. 
All the panel types in the project can be found using 
the Document.CurtainPanelTypes property.

