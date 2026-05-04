---
kind: method
id: M:Autodesk.Revit.DB.Document.GetHashCode
zh: 文档、文件
source: html/006a71c2-4393-e036-9987-14467342a7d3.htm
---
# Autodesk.Revit.DB.Document.GetHashCode Method

**中文**: 文档、文件

Gets the hash code of this document instance.

## Syntax (C#)
```csharp
public override int GetHashCode()
```

## Remarks
The hash code is the same for document instances that represent the same document currently opened in the Revit session.
The hash code is generated when a Revit file is opened or created in session. 
If the same Revit file is opened later (in the same session or a different session) the hash code will not be the same.

