---
kind: type
id: T:Autodesk.Revit.DB.ITransientElementMaker
source: html/0d213d8b-eace-f2ff-bd02-3bbd948a6dec.htm
---
# Autodesk.Revit.DB.ITransientElementMaker

The interface to be implemented by an application that creates transient element(s) in Revit.

## Syntax (C#)
```csharp
public interface ITransientElementMaker
```

## Remarks
An instance of the implemented interface is passed as an argument to the Document.MakeTransientElements() method, which will call back the Execute method of the interface. During the execution of the method Revit will allow creation of certain elements, such as DirectShape, and will make them automatically transient . See ( IsTransient for more details about transient elements.) The code within the Execute method is not allowed to modify the model in any other way. An attempt to change the model or create elements of other kinds will result in an exception. This indirectly means that methods using a transaction internally are not allowed either. Such methods include document Save and SaveAs, certain import and export methods, creating links, syncing with central, etc. Regenerating the model is also not allowed for the entire duration of the Execute method. This interface is passed to MakeTransientElements(ITransientElementMaker) which does the actual transient element creation.

