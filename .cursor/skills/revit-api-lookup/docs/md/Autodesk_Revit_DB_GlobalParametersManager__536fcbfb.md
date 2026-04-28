---
kind: type
id: T:Autodesk.Revit.DB.GlobalParametersManager
source: html/f3af05ec-1f0c-fe86-6708-0a211a40bcda.htm
---
# Autodesk.Revit.DB.GlobalParametersManager

A class to access and query information about global parameters in Revit models.

## Syntax (C#)
```csharp
public class GlobalParametersManager : IDisposable
```

## Remarks
This class provides access to general information and data of Global Parameter
 elements in a particular model. First of all, it is important to know that global
 parameters can be had in main project document; there are not supported in family
 documents. Availability of global parameters in a document can be tested by calling
 AreGlobalParametersAllowed(Document) method. Global Parameter in a document can be obtained by calling either
 GetAllGlobalParameters(Document) or FindByName(Document, String) .
 The former returns a set of all global parameters in the document,
 while the latter returns just the requested one, providing it exists. Each global parameters must be created with a valid name that is unique
 in the scope of the document. To test whether a particular name is unique,
 programmer can use the IsUniqueName(Document, String) method. More details about creating and manipulating global parameters can be found
 in the description of the GlobalParameter class.

