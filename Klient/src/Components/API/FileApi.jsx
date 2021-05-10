  import Swal from "sweetalert2"
  import Api from "./Api";
  import axios from 'axios'

export default class FileApi extends Api{

        constructor()
        {
          super();
        }
        async fetchAllTestFiles() {
                try {
                   const res = await this.baseAxios.get('https://localhost:44323/api/testsFile');     
                   return res.data;
                } catch (error) {
                  Swal.fire("Oops...", "You don't have anyone test files", "error");
                }
              }
              async DownloadTestFile(id) {
                try {
                   await this.baseAxios({
                    url: 'https://localhost:44323/api/testsFile/'+id,
                    method: 'POST',
                           
                    responseType: 'blob'
                  }).then((response) => {
                   const url = window.URL.createObjectURL(new Blob([response.data]));
                    var fileName = parseInt(sessionStorage.getItem("TypeTest"))==0?"MultipleSelectionTest":"SingleSelectionTest"
                    const link = document.createElement('a');
                    link.href = url;
                    link.setAttribute('download', fileName+'.csv');
                    document.body.appendChild(link);
                   link.click();
                  });     
                  
                } catch (error) {
                  Swal.fire("Oops...", "You can't download file", "error");
                }
              }
}