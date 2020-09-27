/*
  This file is licensed to You under the Apache License, Version 2.0
  (the "License"); you may not use this file except in compliance with
  the License.  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/
using System.Xml;

namespace Org.XmlUnit.Input
{
    /// <summary>
    /// Provides a base implementation for the different concrete ISource
    /// implementations.
    /// </summary>
    public abstract class AbstractSource : ISource
    {
        private bool disposed;
        private string systemId;
        private readonly XmlReader reader;
        /// <summary>
        /// Creates a new Source wrapping a reader.
        /// </summary>
        /// <param name="r">the reader to wrap</param>
        protected AbstractSource(XmlReader r)
        {
            reader = r;
            systemId = r.BaseURI;
        }

        /// <inheritdoc/>
        public XmlReader Reader
        {
            get
            {
                return reader;
            }
        }

        /// <inheritdoc/>
        public string SystemId
        {
            get
            {
                return systemId;
            }
            set
            {
                systemId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0} with systemId {1}", GetType().Name,
                                 SystemId);
        }

        public void Dispose() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposed) {
                reader.Close();
                disposed = true;
            }
        }
    }
}
