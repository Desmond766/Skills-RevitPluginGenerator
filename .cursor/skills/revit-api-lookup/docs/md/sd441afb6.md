---
kind: type
id: T:Autodesk.Revit.DB.Form
zh: 对话框、窗口、窗体
source: html/49f6ae4c-1629-98ef-d9a9-799bb1fd43ec.htm
---
# Autodesk.Revit.DB.Form

**中文**: 对话框、窗口、窗体

An object that represents a Form within the Autodesk Revit Massing Family.

## Syntax (C#)
```csharp
public class Form : GenericForm
```

## Remarks
For any reference returned from a Form method, its GeometryObject will become invalid after a form modification method, e.g. MoveSubElement.
Call the method on the Form object to retrieve the new reference if it is needed after the modification.

