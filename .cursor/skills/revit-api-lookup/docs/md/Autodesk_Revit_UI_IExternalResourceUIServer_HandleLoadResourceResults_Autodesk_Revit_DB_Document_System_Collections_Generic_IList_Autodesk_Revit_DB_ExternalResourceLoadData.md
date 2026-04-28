---
kind: method
id: M:Autodesk.Revit.UI.IExternalResourceUIServer.HandleLoadResourceResults(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ExternalResourceLoadData})
source: html/5a6b5313-eca3-8929-4fd2-750d924f06d7.htm
---
# Autodesk.Revit.UI.IExternalResourceUIServer.HandleLoadResourceResults Method

Implement this method to display any UI related to messages or errors that result when the DB server
 associated with this UI server attempts to load an external resource.

## Syntax (C#)
```csharp
void HandleLoadResourceResults(
	Document document,
	IList<ExternalResourceLoadData> loadData
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document into which resources were loaded.
- **loadData** (`System.Collections.Generic.IList < ExternalResourceLoadData >`) - A collection of ExternalResourceLoadData objects containing information about an attempt to load one or more
 external resources,
 including:
 the load request Id the type of resource that was loaded information to identify the particular resource that was loaded the actual content obtained during the load attempt the context of the load operations, e.g. LoadOperationType::Explicit for an explicit loading, LoadOperationType::Automatic for an automatic loading a settable property indicating whether the server reported any errors for the resource The ExternalResourceLoadData contains a property, ErrorsReported, which the server can
 use to indicate whether it handled any errors for the resource. For Revit links specifically, Revit will check this value to see
 if it should report errors about a given link in the Unresolved
 References dialog. An IExternalResourceUIServer can set this value
 to true to avoid redundant messages. Note that it is possible for Revit to encounter errors internally
 even if the server successfully provides a reference. In general, this
 value should only be set to true if the server has reported an
 error condition.

## Remarks
This method will be called automatically by Revit after the external resource load process is complete. Note that automatic loads can occur in the context of other operations such as opening a file.
 During automatic loads, it is therefore recommended that the server only display UI that is critical
 for the user to see (such as error message). The loading operation type is Explicit when the user is specifically trying to reload the resource.
 During explicit loads, it may be desirable to provide more feedback to the user, such as specific feedback
 that the load operation succeeded. The loading operation type can be accessed through ExternalResourceLoadContext . Note that providing messages and other UI feedback for Revit links is more complicated,
 because links can be nested. The UI server may wish to provide different messages and take
 different actions, depending on whether a link loaded from the DB server was a "top-level" link,
 or was nested. For example, while it may be possible to correct an error that occurred with a
 top-level link by loading it directly, this cannot be done with a nested link, as Revit will throw
 an exception. To complicate things further, the same Revit document may appear more than once in a tree of nested
 links, and the UI server should avoid repeatedly posting the same message for instances of that
 document. To help UI servers handle situations where a nested tree of links is loaded:
 Each UI server whose DB server loaded one or more links in the tree will only be called once. The collection of ExternalResourceLoadData objects passed into this method will include
 only those for links loaded by this server's DB server . The LinkLoadResults object contained in all ExternalResourceLoadData objects will always
 be the results for the top-level link, even if the top-level link was not loaded by this
 server's DB server. The LinkLoadResults class contains methods for navigating the full tree of
 load results (starting with the top node), so the UI server will be able to determine the complete
 context in which one of its DB server's resources was loaded. Servers should only report results for their own link, whether they are nested or not.

