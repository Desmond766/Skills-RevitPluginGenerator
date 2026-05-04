---
kind: type
id: T:Autodesk.Revit.DB.SharedParameterElement
source: html/d8a0f2ae-7e10-39bd-e362-3756cbae661b.htm
---
# Autodesk.Revit.DB.SharedParameterElement

An element that stores the definition of a shared parameter which is loaded into the document.

## Syntax (C#)
```csharp
public class SharedParameterElement : ParameterElement
```

## Remarks
Shared parameters are user-defined parameters that can be shared by multiple
 Revit documents. A shared parameter is identified by a GUID.
 Basic information of the shared parameter are accessed through GetDefinition().

