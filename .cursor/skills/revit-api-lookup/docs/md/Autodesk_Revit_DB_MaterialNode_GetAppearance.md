---
kind: method
id: M:Autodesk.Revit.DB.MaterialNode.GetAppearance
source: html/59c4b123-e7bb-4108-595f-ad045e151433.htm
---
# Autodesk.Revit.DB.MaterialNode.GetAppearance Method

Appearance properties associated with the material.

## Syntax (C#)
```csharp
public Asset GetAppearance()
```

## Returns
An instance of a rendering material asset

## Remarks
Properties and attributes of the material's appearance
 can be accessed using the standard interface of the Asset class.
The structure of the properties, including their types and names
 is proprietary and as such it is not always useful to anyone who
 is not familiar with the particular schema. Also, the structure
 is not standardized and may change over time, therefore it is not
 recommended relaying on any appearance property to be present.

